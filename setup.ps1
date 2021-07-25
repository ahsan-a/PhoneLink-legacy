if (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))  
$port = Read-Host "What is your port? (default is 1234)"

{  
  $arguments = "& '" +$myinvocation.mycommand.definition + "'"
  Start-Process powershell -Verb runAs -ArgumentList $arguments
  Break
}

netsh http add urlacl url=http://+:$port/ user="Everyone"
New-NetFirewallRule -DisplayName "Phonelink" -Direction Inbound -LocalPort $port -Protocol TCP -Action Allow