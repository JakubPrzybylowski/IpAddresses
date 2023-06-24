using System;
using System.Collections.Generic;

namespace Ip.Addresses.UI.ViewModels.Mappers
{
    public interface IMapper<TFirst, TSecond>
    {
        List<TFirst> Map(List<TSecond> elements, Action<TFirst> callback = null);
        List<TSecond> Map(List<TFirst> elements, Action<TSecond> callback = null);
    }
}