using ComicMaker.Common.Models;

namespace ComicMaker.Common.Commands
{
    public abstract class CommandQueryBase
    {
        public Credentials Credentials { get; set; } = new Credentials();
    }
}