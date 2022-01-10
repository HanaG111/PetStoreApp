using PetStoreApp.Application.Models;
using PetStoreApp.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreApp.Application.Handlers;

public class FindByIdHandler : IRequestHandler<FindByIdQuery, PetModel>
{
    private readonly IMediator _mediator;

    public FindByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PetModel> Handle(FindByIdQuery request, CancellationToken cancellationToken)
    {
        var results = await _mediator.Send(new GetPetListQuery());

        var output = results.FirstOrDefault(x => x.PetId == request.PetId);

        return output;
    }
}


