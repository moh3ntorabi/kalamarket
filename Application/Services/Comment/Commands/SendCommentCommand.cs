using Application.Dtos;
using Application.Interfaces.Context;
using Domain.Catalogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Comment.Commands
{
    public class CommentDto
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string CatalogItemId { get; set; }
    }
    public class SendCommentCommand:IRequest<BaseDto<SendcommentResponseDto>>
    {
        public SendCommentCommand(CommentDto commentDto)
        {
            Comment = commentDto;
        }
        public CommentDto Comment { get; set; }
    }

    public class SendCommentHandler : IRequestHandler<SendCommentCommand,BaseDto<SendcommentResponseDto>>
    {
        private readonly IDataBaseContext context;

        public SendCommentHandler(IDataBaseContext context)
        {
            this.context = context;
        }
        public Task<BaseDto<SendcommentResponseDto>> Handle(SendCommentCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = context.CatalogItems.Find(Convert.ToInt32(request.Comment.CatalogItemId));
            CatalogItamComment comment = new CatalogItamComment
            {
                Title=request.Comment.Title,
                Email=request.Comment.Email,
                Comment=request.Comment.Comment,
                CatalogItem=catalogItem,
            };
            var entity = context.CatalogItamComments.Add(comment);
            context.SaveChanges();

            return Task.FromResult(new BaseDto<SendcommentResponseDto>
            (
                true,
                new List<string>{ "با موفقیت ثبت شد"},
                new SendcommentResponseDto {Id= entity.Entity.Id }
            ));
        }
    }

    public class SendcommentResponseDto
    {
        public int Id { get; set; }
    }
}
