﻿namespace Bing.Printer.Operations
{
    /// <summary>
    /// 打印样式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IPrintStyle<out T>
    {
        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="value">值</param>
        T LeftMargin(int value = 0);

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="nL">边距值</param>
        /// <param name="nH">高度</param>
        T LeftMargin(int nL, int nH);

        /// <summary>
        /// 设置打印区域宽度
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T PrintWidth(int nL, int nH);

        /// <summary>
        /// 设置相对横向打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T RelativeHorizontalPosition(int nL, int nH);

        /// <summary>
        /// 设置绝对打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T AbsolutePosition(int nL, int nH);

        /// <summary>
        /// 左对齐
        /// </summary>
        T Left();

        /// <summary>
        /// 居中
        /// </summary>
        T Center();

        /// <summary>
        /// 右对齐
        /// </summary>
        /// <returns></returns>
        T Right();
    }
}
