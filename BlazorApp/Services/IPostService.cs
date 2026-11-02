using APIContracts.Posts;

namespace BlazorApp.Services;

public interface IPostService
{
    Task<PostDTO> AddPostAsync(CreatePostDTO request);
    Task<PostDTO> GetPostAsync(int id);
    Task<List<PostDTO>> GetPostsAsync();
}