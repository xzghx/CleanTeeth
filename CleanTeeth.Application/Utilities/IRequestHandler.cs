using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Utilities;

public interface IRequestHandler<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}


/// <summary>
/// Usefull when no reponse is expected
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IRequestHandler<TRequest>
{
    Task Handle(TRequest request);
}
