Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

# ---- SETTINGS YOU CAN CHANGE ----
$shots = 3          # set to 2 or 3
$delaySeconds = 2   # seconds between screenshots
# ---------------------------------

# Save in the same folder as this script
$outDir = $PSScriptRoot

# Take N screenshots
for ($i = 1; $i -le $shots; $i++) {

    Start-Sleep -Seconds $delaySeconds

    $bounds = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
    $bmp = New-Object System.Drawing.Bitmap $bounds.Width, $bounds.Height
    $graphics = [System.Drawing.Graphics]::FromImage($bmp)
    $graphics.CopyFromScreen($bounds.Location, [System.Drawing.Point]::Empty, $bounds.Size)

    $outPath = Join-Path $outDir ("hw_run_screenshot_{0:yyyyMMdd_HHmmss}_{1}.png" -f (Get-Date), $i)

    try {
        $bmp.Save($outPath, [System.Drawing.Imaging.ImageFormat]::Png)
        Write-Host "Saved: $outPath"
    }
    finally {
        $graphics.Dispose()
        $bmp.Dispose()
    }
}
