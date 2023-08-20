using Microsoft.AspNetCore.Mvc;

namespace Web.Command.Commands
{
    public interface ITableActionCommand
    {
        public IActionResult Execute();
    }
}
