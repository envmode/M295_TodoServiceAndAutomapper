﻿using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Models;

namespace M295_TodoServiceAndAutomapper.Services.Abstract
{
    public interface ITodoStatusService : IGenericService<TodoStatus, TodoStatusDTO>
    {
    }
}