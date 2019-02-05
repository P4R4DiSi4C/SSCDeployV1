$hubs = Get-WmiObject Win32_Serialport | Select-Object Name,DeviceID,Description
$powerMgmt = Get-WmiObject MSPower_DeviceEnable -Namespace root\wmi
foreach ($p in $powerMgmt)
{
    $IN = $p.InstanceName.ToUpper()
    foreach ($h in $hubs)
    {
        $PNPDI = $h.PNPDeviceID
        if ($IN -like "*$PNPDI*")
        {
                $p.enable = $False
                $p.psbase.put()
        }
    }
}