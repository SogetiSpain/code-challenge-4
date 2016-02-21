using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    internal class FormatDimensions
    {


        public int FullNameWidth { get; set; }
        public int PositionWidth { get; set; }
        public int SeparationDateWidth { get; set; }

        public FormatDimensions(IEnumerable<Employee> employees)
        {
            this.FullNameWidth = employees.Max(x => x.FullName.Length) + 3;
            this.PositionWidth = employees.Max(x => x.Position.Length) + 3;
            this.SeparationDateWidth = DateTime.MinValue.ToShortDateString().Length + 2;
        }

        public string ToFormatString()
        {
            StringBuilder sb = new StringBuilder();
            AppendFormatParameter(sb, this.FullNameWidth, 0);
            sb.Append("| ");
            AppendFormatParameter(sb, this.PositionWidth, 1);
            sb.Append("| ");
            AppendFormatParameter(sb, this.SeparationDateWidth, 2);
            return sb.ToString();
        }

        public int TotalWidth()
        {
            return this.FullNameWidth + this.PositionWidth + this.SeparationDateWidth + 9;
        }

        private void AppendFormatParameter(StringBuilder sb, int width, int position)
        {
            sb.AppendFormat("{{{0},-{1}}}", position, width);
        }

    }
}
