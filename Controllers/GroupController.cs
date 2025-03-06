using AutoMapper;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;
using DecisionDeck.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DecisionDeck.Controllers
{
    public class GroupController : Controller
    {
        private readonly IDecisionRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public GroupController(IDecisionRepository<Models.Group> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_groupRepository.GetAll());
        }

        public IActionResult Edit()
        {
            if (!string.IsNullOrEmpty(Request.Query["GroupId"]))
            {
                int groupId = Convert.ToInt32(Request.Query["GroupId"]);

                var group = _groupRepository.GetById(groupId);

                var groupDTO = _mapper.Map<GroupDTO>(group);

                return View(groupDTO);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] GroupDTO groupDTO)
        {
            if (groupDTO != null)
            {
                _groupRepository.Delete(groupDTO.GroupId);

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Update([FromBody] GroupDTO groupDTO)
        {
            if (groupDTO == null)
            {
                return Json(new { success = false });
            }

            var user = _mapper.Map<Group>(groupDTO);

            _groupRepository.Update(user);

            return Json(new { success = true });
        }
    }
}
