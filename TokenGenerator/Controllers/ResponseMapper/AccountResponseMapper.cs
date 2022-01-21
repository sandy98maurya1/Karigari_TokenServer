using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace eFlowerPortal.ResponseMapper
{
    public static class AccountResponseMapper
    {
        public static TokenResponse SystemUserNotExist()
        {
            return new TokenResponse()
            {
                IsSuccess = false,
                Error = Messages.LoginFail,
                Error_description = Messages.LoginFail,
            };
        }

        public static TokenResponse ModelErrorTokenResponse()
        {
            return new TokenResponse()
            {
                IsSuccess = false,
                Error = Messages.UserOrPasswordEmpty,
                Error_description = Messages.UserOrPasswordEmpty,
            };
        }

        //public static OTPResponse<User> GetOtpResponse(this bool result, TokenRequest request, string otp)
        //{
        //    if (result && !string.IsNullOrEmpty(otp))
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = request.Username,
        //            IsOTPVerify = true,
        //            Contact = request.Contact,
        //            Message = Messages.Success,
        //            Data = null,
        //            StatusCode = "200"
        //        };
        //    }
        //    else
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = request.Username,
        //            IsOTPVerify = false,
        //            Contact = request.Contact,
        //            Message = Messages.OTPFail,
        //            Data = null,
        //            StatusCode = "500"
        //        };
        //    }
        //}

        //public static OTPResponse<User> GetOtpResponse(this bool result, User request, string otp)
        //{
        //    if (result && !string.IsNullOrEmpty(otp))
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = request.Username,
        //            IsOTPVerify = true,
        //            Contact = request.Contact,
        //            Message = Messages.Success,
        //            Data = null,
        //            StatusCode = "200"
        //        };
        //    }
        //    else
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = request.Username,
        //            IsOTPVerify = false,
        //            Contact = request.Contact,
        //            Message = Messages.OTPFail,
        //            Data = null,
        //            StatusCode = "500"
        //        };
        //    }
        //}

        //public static OTPResponse<User> GetOtpWithUserResponse(this User model,string otp)
        //{
        //    if (model != null && !string.IsNullOrEmpty(otp))
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = model.Username,
        //            IsOTPVerify = true,
        //            Contact = model.Contact,
        //            Message = Messages.Success,
        //            Data = model,
        //            StatusCode = "200"
        //        };
        //    }
        //    else
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = model.Username,
        //            IsOTPVerify = false,
        //            Contact = model.Contact,
        //            Message = Messages.OTPFail,
        //            Data = null,
        //            StatusCode = "500"
        //        };
        //    }
        //}

        //public static OTPResponse<User> GetVerifiedOtpResponse(this User model, string otp)
        //{
        //    if (model != null && !string.IsNullOrEmpty(otp))
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = model.Username,
        //            IsOTPVerify = true,
        //            Contact = model.Contact,
        //            Message = Messages.OTPValidated,
        //            Data = model,
        //            StatusCode = "200"
        //        };
        //    }
        //    else
        //    {
        //        return new OTPResponse<User>()
        //        {
        //            OTP = otp,
        //            FullName = model.Username,
        //            IsOTPVerify = false,
        //            Contact = model.Contact,
        //            Message = Messages.OTPFail,
        //            Data = null,
        //            StatusCode = "500"
        //        };
        //    }
        //}

        //public static OTPResponse<User> OtpExpireResponse(TokenRequest request)
        //{
        //    return new OTPResponse<User>()
        //    {
        //        OTP = request.OTP,
        //        FullName = request.Username,
        //        IsOTPVerify = false,
        //        Contact = request.Contact,
        //        Message = Messages.OTPExpired,
        //        Data = null,
        //        StatusCode = "500"
        //    };
        //}

        //public static OTPResponse<User> OtpFaileResponse(TokenRequest request)
        //{
        //    return new OTPResponse<User>()
        //    {
        //        IsOTPVerify = false,
        //        Contact = request.Contact,
        //        Message = Messages.OTPFail,
        //        Data = null,
        //        StatusCode = "500"
        //    };
        //}

        //public static OTPResponse<User> UserNotExist(TokenRequest request)
        //{
        //    return new OTPResponse<User>()
        //    {
        //        IsOTPVerify = false,
        //        Contact = request.Contact,
        //        Message = string.Format(Messages.ValueNotExists, "User", request.Contact),
        //        Data = null,
        //        StatusCode = "500"
        //    };
        //}

        public static OTPResponse<User> CacheExceptionResponse(this Exception ex)
        {
            return new OTPResponse<User>
            {
                IsOTPVerify = false,
                Data = null,
                Message = ex.Message,
                StatusCode = "500"
            };
        }
    }
}
