﻿using Flunt.Notifications;
using System.Collections.Generic;

namespace TreasuryChallenge.Domain.Commands.Result
{
    public class GetLinesAmountToWriteCommandResult
    {
        public GetLinesAmountToWriteCommandResult(bool success, string message, long elapsedMilliseconds, int statusCode, IEnumerable<Notification> notifications)
        {
            Success = success;
            Message = message;
            ElapsedMilliseconds = elapsedMilliseconds;
            StatusCode = statusCode;
            Notifications = notifications;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
