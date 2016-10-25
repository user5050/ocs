using System;

namespace Lpn.Service.TrdPart.Partner.TianHong.Api.Model
{ 
    [Serializable]
    public class RetObj
    {
        /// <summary>
        /// 结果编码
        /// </summary> 
        public int Code { get; set; }
 
        /// <summary>
        /// 描述
        /// </summary> 
        public string Message { get; set; }


        /// <summary>
        /// 附件对象
        /// </summary> 
        public object Result { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary> 
        public bool IsSuccess { get { return Code == (int)RetState.Success; } }


        public static RetObj DefaultError(int state, object data)
        {
            return new RetObj { Result = data, Code = state };
        }

        public static RetObj DefaultError(int state, string errorMsg)
        {
            return new RetObj { Message = errorMsg, Code = state };
        }

        public static RetObj DefaultError(int state)
        {
            return new RetObj { Result = null, Code = state };
        }

        public static RetObj DefaultError(RetState state, string errorMsg)
        {
            return new RetObj { Message = errorMsg, Code = (int)state };
        }

        public static RetObj DefaultError(RetState state)
        {
            return new RetObj { Result = null, Code = (int)state };
        }

        public static RetObj DefaultSuccess(object data)
        {
            return new RetObj { Result = data, Code = (int)RetState.Success };
        }

        public static RetObj DefaultSuccess(object data, int total)
        {
            return new RetObj { Result = data, Code = (int)RetState.Success};
        }

        public static RetObj DefaultSuccess()
        {
            return new RetObj { Code = (int)RetState.Success };
        }
    }


    [Serializable]
    public class RetObj<T>
    {
        /// <summary>
        /// 结果编码
        /// </summary> 
        public int Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary> 
        public string Message { get; set; }


        /// <summary>
        /// 附件对象
        /// </summary> 
        public T Result { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary> 
        public bool IsSuccess { get { return Code == (int)RetState.Success; } }


        public static RetObj<T> DefaultError(int state, string errorMsg)
        {
            return new RetObj<T> { Message = errorMsg, Code = state };
        }

        public static RetObj<T> DefaultError(RetState state, string errorMsg)
        {
            return new RetObj<T> { Message = errorMsg, Code = (int)state };
        }

        public static RetObj<T> DefaultError(RetState state)
        {
            return new RetObj<T> { Result = default(T), Code = (int)state };
        }

        public static RetObj<T> DefaultSuccess(T data)
        {
            return new RetObj<T> { Result = data, Code = (int)RetState.Success };
        }
 
        public static RetObj<T> DefaultSuccess()
        {
            return new RetObj<T> { Code = (int)RetState.Success };
        }
    }
}
