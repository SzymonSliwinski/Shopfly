﻿using System.Collections.Generic;

namespace Common.Models.ShopPanelModels
{
    public class Privilege
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
    }
}