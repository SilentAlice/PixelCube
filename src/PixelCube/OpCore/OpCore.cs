﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Leap;
using PixelCube.LeapMotion;
using PixelCube.Scene3D;


namespace PixelCube.OpCore
{

    /// <summary>
    /// 操作核心实现类
    /// </summary>
    public class OpCore
    {
        #region 成员变量
        #region 核心操作类的事件
        /// <summary>
        /// 焦点变化事件
        /// </summary>
        public event EventHandler<PostFocusOperationEventArgs> PostFocusOperationEvent;

        /// <summary>
        /// 小方块着色事件
        /// </summary>
        public event EventHandler<PostDrawOperationEventArgs> PostDrawOperationEvent;

        /// <summary>
        /// 世界角度变换事件
        /// </summary>
        public event EventHandler<PostRotateOperationEventArgs> PostRotateOperationEvent;

        /// <summary>
        /// 世界缩放事件
        /// </summary>
        public event EventHandler<PostScaleOperationEventArgs> PostScaleOperationEvent;

        #endregion

        private IArtwork martwork;
        private int mcubea;//小方块的边长

        #endregion

        public OpCore()
        {
        }
        #region 成员方法

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="win">框架实例</param>
        public void DoInit(MainWindow win)
        {
            martwork = win.CurrentArt;
            //获取小方块的边长
            mcubea = (int)win.FindResource("cubeA");
        }

        #region 事件响应函数
        /// <summary>
        /// 焦点变化响应函数
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        public void OnPreFocusOperation(object sender, PreFocusOperationEventArgs e)
        {
            Vector curPosition = e.FocusPosition;
            //x,y,z为小方块的绝对三维坐标
            int x = (int)curPosition.x;
            int y = (int)curPosition.y;
            int z = (int)curPosition.z;

            //i,j,k为小方块的三维位置索引
            int i = x / mcubea;
            int j = y / mcubea;
            int k = z / mcubea;
            //计算出小方块在链表中的索引
            int index = i + (int)martwork.SceneSize.X * j + (int)martwork.SceneSize.Y * k;
            
            //获取指定小方块
            ICube cube = martwork.Cubes[index];

            //修改其属性
            //cube.visible = true;

            //发出事件
            if (PostFocusOperationEvent != null)
            {
                PostFocusOperationEvent(this, new PostFocusOperationEventArgs(index));
            }
        }

        /// <summary>
        /// 着色响应函数
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        public void OnPreDrawOperation(object sender, PreDrawOperationEventArgs e)
        {
        }

        /// <summary>
        /// 旋转变化响应函数
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        public void OnPreRotateOperation(object sender, PreRotateOperationEventArgs e)
        {

        }

        /// <summary>
        /// 缩放响应函数
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        public void OnPreScaleOperation(object sender, PreScaleOperationEventArgs e)
        {
        }
        #endregion
        #endregion
    }
}