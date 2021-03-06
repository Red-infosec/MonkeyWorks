﻿using System;

namespace MonkeyWorks.SMB.SMB2
{
    sealed class SMB2FindFileRequestFile
    {
        private readonly Byte[] StructureSize = { 0x21, 0x00 };
        private Byte[] InfoLevel = { 0x25 };
        private readonly Byte[] Flags = { 0x00 };
        private readonly Byte[] FileIndex = { 0x00, 0x00, 0x00, 0x00 };
        private Byte[] FileID = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
        private readonly Byte[] SearchPattern_Offset = { 0x60, 0x00 };
        private readonly Byte[] SearchPattern_Length = { 0x02, 0x00 };
        private Byte[] OutputBufferLength = { 0x00, 0x00, 0x01, 0x00 };
        private readonly Byte[] SearchPattern = { 0x2a, 0x00 };
        private Byte[] Padding = new Byte[0];

        internal SMB2FindFileRequestFile()
        {
        }

        internal void SetInfoLevel(Byte[] InfoLevel)
        {
            if (InfoLevel.Length == this.InfoLevel.Length)
            {
                this.InfoLevel = InfoLevel;
            }
        }

        internal void SetFileID(Byte[] FileID)
        {
            if (FileID.Length == this.FileID.Length)
            {
                this.FileID = FileID;
            }
        }

        internal void SetOutputBufferLength(Byte[] OutputBufferLength)
        {
            if (OutputBufferLength.Length == this.OutputBufferLength.Length)
            {
                this.OutputBufferLength = OutputBufferLength;
            }
        }

        internal void SetPadding(Byte[] Padding)
        {
            this.Padding = Padding;
        }

        internal Byte[] GetRequest()
        {
            Byte[] request = Combine.combine(StructureSize, InfoLevel);
            request = Combine.combine(request, Flags);
            request = Combine.combine(request, FileIndex);
            request = Combine.combine(request, FileID);
            request = Combine.combine(request, SearchPattern_Offset);
            request = Combine.combine(request, SearchPattern_Length);
            request = Combine.combine(request, OutputBufferLength);
            request = Combine.combine(request, SearchPattern);
            request = Combine.combine(request, Padding);
            return request;
        }
    }
}
