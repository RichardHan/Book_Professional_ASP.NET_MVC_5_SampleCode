$answers =   "As I see it, yes",
                   "Reply hazy, try again",
                   "Outlook not so good"
function Get-Answer($question) {
      $rand = New-Object System.Random
      return $answers[$rand.Next(0, $answers.Length)]
}

Register-TabExpansion 'Get-Answer' @{
      'question' = {
             "Is this my lucky day?",
             "Will it rain tonight?",
             "Do I watch too much TV?"
      }
}

Export-ModuleMember Get-Answer