using AutoMapper;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace DecisionDeck.Controllers
{
    public class PollController : Controller
    {
        private readonly IDecisionRepository<Group> _decisionRepository;
        private readonly IPollOptionRepository _pORepository;
        private readonly IPollRepository _repository;
        private readonly IMapper _mapper;

        public PollController(IDecisionRepository<Group> decisionRepository, IPollOptionRepository PORepository, IPollRepository repository, IMapper mapper)
        {
            _decisionRepository = decisionRepository;
            _pORepository = PORepository;
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult AddPoll()
        {
            return View(_decisionRepository.GetAll());
        }

        public IActionResult Result()
        {
            if (!string.IsNullOrEmpty(Request.Query["PollId"]))
            {
                try
                {
                    int pollId = Convert.ToInt32(Request.Query["PollId"]);

                    var pollDTO = _mapper.Map<PollDTO>(_repository.GetById(pollId));

                    var pollOptions = _pORepository.GetByPollId(pollId).ToList();
                    var totalVotes = _pORepository.GetByPollId(pollId).Sum(po => po.SelectedCount);

                    var result = new ResultDTO();

                    result.Poll = pollDTO;

                    foreach (var option in pollOptions)
                    {
                        double percent = (option.SelectedCount.GetValueOrDefault() / (double)totalVotes) *100;
                        double formattedPercent = Convert.ToDouble(String.Format("{0:0.0}", percent));

                        var resultOption = new ResultOptionDTO()
                        {
                            OptionName = option.OptionName,
                            Percentage = formattedPercent
                        };

                        result.OptionResults.Add(resultOption);
                    }

                    return View(result);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult ShowPoll()
        {
            if (!string.IsNullOrEmpty(Request.Query["PollId"]))
            {
                try
                {
                    int pollId = Convert.ToInt32(Request.Query["PollId"]);

                    var poll = _repository.GetById(pollId);
                    var pollOption = _pORepository.GetByPollId(pollId);
                    var pollDTO = _mapper.Map<PollDTO>(poll);

                    foreach (var option in pollOption)
                    {
                        pollDTO.OptionList.Add(option.OptionName);
                    }

                    return View(pollDTO);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreatePoll([FromBody] PollDTO pollDTO)
        {
            if (pollDTO.OptionList.Count == 0)
            {
                return Json(new { success = false });
            }

            var newPoll = _mapper.Map<Models.Poll>(pollDTO);

            var newPollId = _repository.Add(newPoll);

            foreach (var option in pollDTO.OptionList)
            {
                var newPollOption = new PollOption()
                {
                    PollId = newPollId,
                    OptionName = option,
                    SelectedCount = 0
                };

                _pORepository.Add(newPollOption);
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UpdatePoll([FromBody] VoteDTO voteDTO)
        {
            if (voteDTO == null)
            {
                return Json(new { success = false });
            }

            var pollOption = _pORepository.GetByPollIdAndOptionName(voteDTO);

            if (pollOption == null)
            {
                return Json(new { success = false });
            }

            pollOption.SelectedCount++;

            _pORepository.Update(pollOption);

            return Json(new { success = true });
        }
    }
}
