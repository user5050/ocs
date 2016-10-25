using System;
using OneCoin.Service.Model.Enum;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Result
{
    [Serializable]
    public class ResultDto
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }

        /// <summary>
        /// 结果总数
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }


        /// <summary>
        /// 附件对象
        /// </summary>
        [JsonProperty("result",NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

     
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get { return State == (int) ResultState.Success; } }


        public static ResultDto DefaultError(int state, object data)
        {
            return new ResultDto { Result = data, State = state };
        }

        public static ResultDto DefaultError(int state, string errorMsg)
        {
            return new ResultDto { Desc = errorMsg, State = state };
        }

        public static ResultDto DefaultError(int state)
        {
            return new ResultDto { Result = null, State = state };
        }

        public static ResultDto DefaultError(ResultState state, string errorMsg)
        {
            return new ResultDto { Desc = errorMsg, State = (int)state };
        }

        public static  ResultDto DefaultError(ResultState state)
        {
            return new ResultDto { Result = null, State = (int)state };
        }

        public static  ResultDto DefaultSuccess(object data)
        {
            return new ResultDto { Result = data, State = (int)ResultState.Success };
        }

        public static ResultDto DefaultSuccess(object data,int total)
        {
            return new ResultDto { Result = data, State = (int)ResultState.Success, Total = total };
        }

        public static  ResultDto DefaultSuccess()
        {
            return new ResultDto { State = (int)ResultState.Success };
        } 
    }


    [Serializable]
    public class ResultDto<T>
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }

        /// <summary>
        /// 结果总数
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }


        /// <summary>
        /// 附件对象
        /// </summary>
        [JsonProperty("result",NullValueHandling = NullValueHandling.Ignore)]
        public T Result { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get { return State == (int)ResultState.Success; } }


        public static ResultDto<T> DefaultError(int state, string errorMsg)
        {
            return new ResultDto<T> { Desc = errorMsg, State = state };
        }

        public static ResultDto<T> DefaultError(ResultState state, string errorMsg)
        {
            return new ResultDto<T> { Desc = errorMsg, State = (int)state };
        }

        public static ResultDto<T> DefaultError(ResultState state)
        {
            return new ResultDto<T> { Result = default(T), State = (int)state };
        }

        public static ResultDto<T> DefaultSuccess(T data)
        {
            return new ResultDto<T> { Result = data, State = (int)ResultState.Success };
        }

        public static ResultDto<T> DefaultSuccess(T data, int total)
        {
            return new ResultDto<T> { Result = data, State = (int)ResultState.Success, Total = total };
        }

        public static ResultDto<T> DefaultSuccess()
        {
            return new ResultDto<T> { State = (int)ResultState.Success };
        }
    }
}
