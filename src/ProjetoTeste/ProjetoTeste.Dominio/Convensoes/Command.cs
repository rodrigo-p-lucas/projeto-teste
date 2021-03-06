﻿using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Dominio
{
    public abstract class Command : IRequest<string>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        //public abstract bool IsValid();
        public abstract string ErrorMessage();
    }
}
