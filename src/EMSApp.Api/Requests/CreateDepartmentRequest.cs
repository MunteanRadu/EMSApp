namespace EMSApp.Api;

public record CreateDepartmentRequest(
    string Name,
    string ManagerId
);