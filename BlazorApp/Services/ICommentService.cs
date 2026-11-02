using APIContracts.Comments;

namespace BlazorApp.Services;

public interface ICommentService
{
    Task<CommentDTO> AddCommentAsync(CreateCommentDTO request);
    Task<List<CommentDTO>> GetCommentsAsync(int postId);
}