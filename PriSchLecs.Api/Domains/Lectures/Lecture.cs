﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Domains.Lectures
{
    public class Lecture : BaseEntityByInt
    {
        /// <summary>
        /// Tên bài giảng
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nội dung bài giảng
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Mô tả bài giảng
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Số lượt xem
        /// </summary>
        public int View { get; set; }

        /// <summary>
        /// Số lượt tải
        /// </summary>
        public int Download { get; set; }

    }
}
