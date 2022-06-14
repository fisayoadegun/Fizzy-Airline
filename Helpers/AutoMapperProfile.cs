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

            CreateMap<Flight, FlightUpdateRequestDto>().ReverseMap();
            CreateMap<Flight, FlightDto>()
                .ForMember(d => d.GoingFrom, opt => opt.MapFrom(src => src.GoingFrom.LocationName))
                .ForMember(d => d.ArrivingAt, opt => opt.MapFrom(src => src.ArrivingAt.LocationName))
                .ForMember(d => d.Airplane, opt => opt.MapFrom(src => src.Airplane.Model))
                .ForMember(d => d.Manufacturer, opt => opt.MapFrom(src => src.Airplane.Manufacturer))
                .ForMember(d => d.NumberOfSeats, opt => opt.MapFrom(src => src.Airplane.NumberOfSeats))
                .ForMember(d => d.FirstPilot, opt => opt.MapFrom(src => src.FirstPilot.FirstName))
                .ForMember(d => d.FirstPilotLastName, opt => opt.MapFrom(src => src.FirstPilot.LastName))
                .ForMember(d => d.SecondPilot, opt => opt.MapFrom(src => src.SecondPilot.FirstName))
                .ForMember(d => d.SecondPilotLastName, opt => opt.MapFrom(src => src.SecondPilot.LastName))
                .ForMember(d => d.FirstFlightAttendant, opt => opt.MapFrom(src => src.FirstFlightAttendant.FirstName))
                .ForMember(d => d.FirstFlightAttendantLastName, opt => opt.MapFrom(src => src.FirstFlightAttendant.LastName))
                .ForMember(d => d.SecondFlightAttendant, opt => opt.MapFrom(src => src.SecondFlightAttendant.FirstName))
                .ForMember(d => d.SecondFlightAttendantLastName, opt => opt.MapFrom(src => src.SecondFlightAttendant.LastName))
                .ForMember(d => d.ThirdFlightAttendant, opt => opt.MapFrom(src => src.ThirdFlightAttendant.FirstName))
                .ForMember(d => d.ThirdFlightAttendantLastName, opt => opt.MapFrom(src => src.ThirdFlightAttendant.LastName));
                
            CreateMap<Flight, FlightCreationDto>().ReverseMap();
            CreateMap<FlightUpdateDto, Flight>()
                 .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));

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

            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationCreationDto>();
            CreateMap<LocationUpdateDto, Location>()
                 .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));

            CreateMap<Pilot, PilotDto>().ReverseMap();
            CreateMap<Pilot, PilotCreationDto>().ReverseMap();
            CreateMap<PilotUpdateDto, Pilot>()
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
            CreateMap<VerificationMailDto, Account>();  

            CreateMap<RegisterRequest, Passenger>();
            CreateMap<Passenger, PassengerResponse>();

            CreateMap<Ticket, TicketDto>()
                .ForMember(d => d.GoingFrom, opt => opt.MapFrom(src => src.GoingFrom.LocationName))
                .ForMember(d => d.ArrivingAt, opt => opt.MapFrom(src => src.ArrivingAt.LocationName))
                .ForMember(d => d.FlightModel, opt => opt.MapFrom(src => src.Flight.Airplane.Model))
                .ForMember(d => d.PassengerFirstName, opt => opt.MapFrom(src => src.Passenger.FirstName))
                .ForMember(d => d.PassengerLastName, opt => opt.MapFrom(src => src.Passenger.LastName));
            CreateMap<TicketCreationDto, Ticket>();
            CreateMap<TicketCreationDto, BoardingPass>();
            CreateMap<Flight, TicketCreationDto>().ReverseMap();
            CreateMap<TicketUpdateDto, Ticket>()
                .ForAllMembers(x => x.Condition(
                   (src, dest, prop) =>
                   {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                       if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                       return true;
                   }
               ));

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