#find relevant network adapters
$nics = Get-WmiObject Win32_NetworkAdapter | where {$_.Name.Contains('Intel')}

$nicsFound = $nics.Count

foreach ($nic in $nics)
{
   $powerMgmt = Get-WmiObject MSPower_DeviceEnable -Namespace root\wmi | where {$_.InstanceName -match [regex]::Escape($nic.PNPDeviceID)}
 
   # check to see if power management can be turned off
   if(Get-Member -inputobject $powerMgmt -name "Enable" -Membertype Properties){

     # check if powermanagement is enabled
     if ($powerMgmt.Enable -eq $True){
       $powerMgmt.Enable = $False
       $powerMgmt.psbase.Put()
     }
   }
}