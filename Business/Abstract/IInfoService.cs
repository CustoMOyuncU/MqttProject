using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IInfoService
    {
        IResult PublishMessage(object message);
        IResult TurnOffLight(object command);
        IResult TurnOnLight(object command);
    }
}
