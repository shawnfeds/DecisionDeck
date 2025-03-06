using AutoMapper;

namespace DecisionDeck.MappingProfiles
{
    public class DecisionDeckProfiles: Profile
    {
        public DecisionDeckProfiles()
        {
            CreateMap<DataAccessObjects.UserDTO, Models.User>().ReverseMap();
            CreateMap<DataAccessObjects.PollDTO, Models.Poll>().ReverseMap();
            CreateMap<DataAccessObjects.GroupDTO, Models.Group>().ReverseMap();
        }
    }
}
