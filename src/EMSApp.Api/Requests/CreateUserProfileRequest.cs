namespace EMSApp.Api;

public record CreateUserProfileRequest(
    string Name,
    string JobTitle,
    int Age,
    string Phone,
    string Address,
    string EmergencyContact
);
