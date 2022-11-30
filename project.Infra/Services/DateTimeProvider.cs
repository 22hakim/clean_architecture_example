using System;
using project.Application.Common.Interfaces.Services;

namespace project.Infra.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}

 