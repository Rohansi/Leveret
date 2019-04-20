﻿using MediatR;
using Mond;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using TIKSN.Leveret.BusinessLogic.Messages;

namespace TIKSN.Leveret.BusinessLogic.Handlers
{
    public class ValueFormatBigIntegerBehavior : IPipelineBehavior<ValueFormatRequest, string>
    {
        public Task<string> Handle(ValueFormatRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<string> next)
        {
            if (request.MondValue.Type == MondValueType.Number && BigInteger.TryParse(request.MondValue.ToString(), out BigInteger bigInteger))
            {
                return Task.FromResult(bigInteger.ToString("N0"));
            }

            return next();
        }
    }
}