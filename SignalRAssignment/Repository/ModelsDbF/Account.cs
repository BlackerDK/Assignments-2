﻿using System;
using System.Collections.Generic;

namespace Repository.ModelsDbF;

public partial class Account
{
    public int AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int Type { get; set; }
}
