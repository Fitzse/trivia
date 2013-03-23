PARAM($exe = "Trivia.exe", $testFile = "test_cases2.txt", $goldenFile = "test_cases.txt")
IF(Test-Path $testFile){
	Remove-Item $testFile
}
iex "&'$exe' 111453" | Out-File $testFile -append 
iex "&'$exe' 1231231" | Out-File $testFile -append 
iex "&'$exe' 24234" | Out-File $testFile -append 
iex "&'$exe' 143124" | Out-File $testFile -append 
iex "&'$exe' 987383" | Out-File $testFile -append 
iex "&'$exe' 111" | Out-File $testFile -append 
iex "&'$exe' 8992834" | Out-File $testFile -append 
iex "&'$exe' 043985" | Out-File $testFile -append 
iex "&'$exe' 234234" | Out-File $testFile -append 
$goldenData = Get-Content $goldenFile
$testData = Get-Content $testFile
diff $goldenData $testData