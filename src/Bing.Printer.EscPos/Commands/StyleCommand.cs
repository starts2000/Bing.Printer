﻿using System.Text;
using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 样式操作
    /// </summary>
    internal class StyleCommand : IStyle<byte[]>
    {
        /// <summary>
        /// 打印纸
        /// </summary>
        private IPrintPaper _printPaper;

        /// <summary>
        /// 字符编码
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// 初始化一个<see cref="StyleCommand"/>类型的实例
        /// </summary>
        /// <param name="printPaper">打印纸</param>
        /// <param name="encoding">字符编码</param>
        public StyleCommand(IPrintPaper printPaper, Encoding encoding)
        {
            _printPaper = printPaper;
            _encoding = encoding;
        }

        /// <summary>
        /// 设置打印样式
        /// </summary>
        /// <param name="style">打印样式</param>
        public byte[] Styles(PrintStyle style) => new[] {ASCIIControlConst.ESC, CommandConst.Chars.StyleMode, style.ToByte()};

        /// <summary>
        /// 设置字符间距
        /// </summary>
        /// <param name="spaceCount">空格数</param>
        public byte[] RightCharacterSpacing(int spaceCount) => new[] { ASCIIControlConst.ESC, CommandConst.Chars.RightCharacterSpacing, spaceCount.ToByte() };

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public byte[] Size(int size) => GetFontSizeSetBig(size);

        /// <summary>
        /// 设置分隔符
        /// </summary>
        public byte[] Separator() => _encoding.GetBytes(new string('-', _printPaper.GetLineStringWidth(2)));

        /// <summary>
        /// 获取字体表达为标准的n倍
        /// </summary>
        /// <param name="size">倍数</param>
        private static byte[] GetFontSizeSetBig(int size)
        {
            byte realSize = 0;
            switch (size)
            {
                case 0:
                    realSize = 0;
                    break;
                case 1:
                    realSize = 17;
                    break;
                case 2:
                    realSize = 34;
                    break;
                case 3:
                    realSize = 51;
                    break;
                case 4:
                    realSize = 68;
                    break;
                case 5:
                    realSize = 85;
                    break;
                case 6:
                    realSize = 102;
                    break;
                case 7:
                    realSize = 119;
                    break;
            }

            return new[] {ASCIIControlConst.GS, ASCIIShowConst.Bang, realSize};
        }
    }
}
