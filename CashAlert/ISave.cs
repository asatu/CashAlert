#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Threading.Tasks;

namespace XAMLtoPDF
{
    public interface ISave
    {
        void Save(string filename, string contentType, MemoryStream stream);
        Task<byte[]> CaptureAsync();
    }
    public interface ISaveWindowsPhone
    {
        Task Save(string filename, string contentType, MemoryStream stream);
        Task<byte[]> CaptureAsync();
    }   
}
