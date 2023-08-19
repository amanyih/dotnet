
using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Persistence.Contracts;
public interface ICommentRepository : IGenericRepository<Comment> {

    Task<IReadOnlyList<Comment>> GetByPostId(int postId);

}