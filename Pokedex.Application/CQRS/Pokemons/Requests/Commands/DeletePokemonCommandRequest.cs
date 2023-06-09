﻿using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Commands
{
    public class DeletePokemonCommandRequest : IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public DeletePokemonCommandRequest(int id)
        {
            Id = id;
        }
    }
}
