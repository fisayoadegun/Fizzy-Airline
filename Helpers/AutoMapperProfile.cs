using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Dtos.Accounts;
using Fizzy_Airline.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<Airplane, AirplaneDto>().ReverseMap();
            CreateMap<Airplane, AirplaneCreationDto>().ReverseMap();
            CreateMap<CreateRequest, Account>();

            CreateMap<Flight_Attendant, FlightAttendantDto>().ReverseMap();
            CreateMap<Flight_Attendant, FlightAttendantCreationDto>().ReverseMap();
            CreateMap<FlightAttendantUpdateDto, Flight_Attendant>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));

            CreateMap<RegisterRequest, Account>();                      

            CreateMap<RegisterRequest, Passenger>();
            CreateMap<Passenger, PassengerResponse>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            CreateMap<UpdateRequest, Passenger>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));


        }
    }
}