using AutoMapper;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;
using DecisionDeck.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace DecisionDeck.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IDecisionRepository<Group> _groupRepository;
        private readonly IDecisionRepository<Role> _roleRepository;

        public UserController(IUserRepository userRepository, 
            IMapper mapper,
            IDecisionRepository<Models.Group> groupRepository,
            IDecisionRepository<Models.Role> roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
            _roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            return View(_userRepository.GetAll());
        }

        public IActionResult Edit()
        {
            if (!string.IsNullOrEmpty(Request.Query["UserId"]))
            {
                int userId = Convert.ToInt32(Request.Query["UserId"]);

                var user = _userRepository.GetById(userId);

                var userDTO = _mapper.Map<UserDTO>(user);

                userDTO.Roles = _roleRepository.GetAll().ToList();
                userDTO.Groups = _groupRepository.GetAll().ToList();

                return View(userDTO);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] UserDTO userDTO)
        {
            if (userDTO != null)
            {
                _userRepository.Delete(userDTO.UserId);

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return Json(new { success = false });
            }

            var user = _userRepository.GetById(userDTO.UserId);

            user.Username = userDTO.Username;
            user.FullName = userDTO.FullName;
            user.RoleId = userDTO.RoleID;
            user.GroupId = userDTO.GroupID;

            _userRepository.Update(user);

            return Json(new { success = true });
        }
    }
}
