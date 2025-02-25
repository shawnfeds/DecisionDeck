using AutoMapper;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecisionDeck.Controllers
{
    public class PollController : Controller
    {
        private readonly IDecisionRepository<Group> _decisionRepository;
        private readonly IDecisionRepository<PollOption> _pORepository;
        private readonly IPollRepository _repository;
        private readonly IMapper _mapper;

        public PollController(IDecisionRepository<Group> decisionRepository, IDecisionRepository<PollOption> PORepository, IPollRepository repository, IMapper mapper)
        {
            _decisionRepository = decisionRepository;
            _pORepository = PORepository;
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPoll()
        {
            return View(_decisionRepository.GetAll());
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
    }
}
