﻿
Imports Microsoft.Toolkit.Mvvm.ComponentModel
''' <summary>
''' Shared objects between multiple code regions
''' </summary>
Public Class ActiveFolder : Inherits ObservableObject

    Public Property folderName As String
    Public Property analysisResults As List(Of Core.AnalysedFileDetails)
    Public Property poorlyCompressedFiles As List(Of ExtensionResults)
    Public Property steamAppID As Integer
    Public Property WikiPoorlyCompressedFiles As List(Of String)

End Class


' Object used to build submission data to send online after compression
Public Class SteamSubmissionData
    Public Property UID As String
    Public Property SteamID As Integer
    Public Property GameName As String
    Public Property FolderName As String
    Public Property CompressionMode As Integer
    Public Property BeforeBytes As Long
    Public Property AfterBytes As Long
    Public Property PoorlyCompressedExt As List(Of ExtensionResults)

End Class


' Object to get results from existing wiki file
Public Class SteamResultsData

    Public SteamID As Integer
    Public GameName As String
    Public FolderName As String
    Public Confidence As Integer '0=Low, 1=Moderate, 2=High
    Public CompressionResults As New List(Of CompressionResult)
    Public PoorlyCompressedExtensions As Dictionary(Of String, Integer)

End Class


' Used to hold compression results from parsed existing wiki file (above)
Public Class CompressionResult

    Public CompType As Integer
    Public BeforeBytes As Long
    Public AfterBytes As Long
    Public TotalResults As Integer

End Class


'Used to track efficiency of compression and built results for submission to wiki
Public Class ExtensionResults

    Public Property extension As String
    Public Property uncompressedBytes As Long
    Public Property compressedBytes As Long
    Public Property totalFiles As Integer
    ReadOnly Property cRatio As Decimal
        Get
            Return Math.Round(compressedBytes / uncompressedBytes, 2)
        End Get
    End Property

End Class