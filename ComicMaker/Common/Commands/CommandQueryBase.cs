using ComicMaker.Common.Models;

namespace ComicMaker.Common.Commands
{
    public abstract class CommandQueryBase
    {
        public Credentials Credentials { get; set; } = new Credentials();
    }

    public interface IIdCommandQuery
    {
        string Id { get; }
        Credentials Credentials { get; }
    }
}