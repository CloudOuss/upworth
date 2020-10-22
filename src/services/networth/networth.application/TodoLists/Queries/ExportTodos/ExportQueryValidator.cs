using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using NetworthApplication.TodoItems.Queries.GetTodoItemsWithPagination;

namespace NetworthApplication.TodoLists.Queries.ExportTodos
{
    public class ExportQueryValidator : AbstractValidator<ExportTodosQuery>
    {
        public ExportQueryValidator()
        {
            RuleFor(x => x.ListId)
                .NotNull()
                .NotEmpty().WithMessage("ListId is required.")
                .Must(x => x > 5).WithMessage("motherfucker");

        }
    }
}
