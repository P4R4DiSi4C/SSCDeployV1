# Obtient les interfaces USB
$hubs = Get-WmiObject Win32_Serialport | Select-Object Name,DeviceID,Description

# Obtient tous les objets avec gestion d'alimentation
$powerMgmt = Get-WmiObject MSPower_DeviceEnable -Namespace root\wmi

# Parcourt les objets avec gestion d'alimentation
foreach ($p in $powerMgmt)
{
	# Stocke le nom d'instance'
    $IN = $p.InstanceName.ToUpper()

	# Parcourt chaque interface USB
    foreach ($h in $hubs)
    {
		# Stocke l'ID de l'interface
        $PNPDI = $h.PNPDeviceID

		# Si l'instance correspond à l'ID
        if ($IN -like "*$PNPDI*")
        {
			# Désactive la gestion d'alimentation
            $p.enable = $False
            $p.psbase.put()
        }
    }
}