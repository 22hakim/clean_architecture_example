using System;
namespace project.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    // les deux sont des possibilités  
    DateTime Now { get; }
    //DateTimeOffset Now { get; }
}






