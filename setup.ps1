$port = 1234 # Change this number to what you want your port to be. Remember to also change it in your App.Config.

if (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))  
{  
  $arguments = "& '" +$myinvocation.mycommand.definition + "'"
  Start-Process powershell -Verb runAs -ArgumentList $arguments
  Break
}

echo "Make sure you are running as Administrator. your current port is $port."
netsh http add urlacl url=http://+:$port/ user="Everyone"
New-NetFirewallRule -DisplayName "Phonelink" -Direction Inbound -LocalPort $port -Protocol TCP -Action Allow