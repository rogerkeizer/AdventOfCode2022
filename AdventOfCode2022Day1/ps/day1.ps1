$inputList = New-Object System.Collections.Generic.List[string]

$root = Split-Path -Path $PSScriptRoot -Parent

$file = ("{0}\input.txt" -f $root);

$fileExists = Test-Path($file);

if ($fileExists -eq $True)
{
    $lines = Get-Content $file;

    $temp = 0;

    Foreach ($line in $lines)
    {
        if ([string]::IsNullOrEmpty($line))
        {
            $inputList.Add($temp);

            $temp = 0;
        }
        else 
        {
            $temp += [int]$line; 
        }
    }

    $orderedList = $inputList | Sort-Object {[int]$_} -Descending;

    Write-Host ("Elf with most calories: {0}" -f $orderedList[0]);

    $three = 0;

    For($i = 0; $i -le 2; $i++)
    {
        $three += $orderedList[$i];
    }

    Write-Host ("Calories of top three Elves: {0}" -f $three);
}
else 
{
    Write-Host("No input found");
}