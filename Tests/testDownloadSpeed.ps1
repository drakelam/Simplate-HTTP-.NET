$urlA = "http://localhost:8000/bin/sampleVideo.mp4"

Write-Output ""
Write-Output "---------"
For($i=0; $i -lt 3; $i++)
{
	$output = "a.temp"
	$start_time = Get-Date
	(New-Object System.Net.WebClient).DownloadFile($urlA, $output)
	Write-Output "SimpleHttp: $((Get-Date).Subtract($start_time).Seconds) second(s)"
}
Write-Output "---------"
Write-Output ""

