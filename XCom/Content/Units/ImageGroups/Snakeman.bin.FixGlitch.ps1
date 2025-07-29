# Read the file
$bytes = [System.IO.File]::ReadAllBytes("c:\git\jacobb\XComGenerations\XCom\Content\Units\ImageGroups\Snakeman.bin")
# Extract the sequence containing the issue (297 bytes)
$segment = $bytes[17560..17856]
# Display the image
for ($i = 0; $i -lt $segment.Length; ++$i) { Write-Host ("Pos {0:D2}: 0x{1:X2} ({1:D3})" -f $i, $segment[$i]) }

# Pos 00: 0x04 (004) # Reserved first byte
# Pos 01: 0xFE (254) # Skip 8
# Pos 02: 0x08 (008)
# Pos 03: 0x2D (045) # Draw (45)
# Pos 04: 0xFE (254) # Skip 29
# Pos 05: 0x1D (029)
# Pos 06: 0x2D (045) # Draw (45) Twice
# Pos 07: 0x2D (045)
# Pos 08: 0xFE (254) # Skip 28
# Pos 09: 0x1C (028)
# Pos 10: 0x2D (045) # Draw (45) Twice
# Pos 11: 0x2D (045)
# Pos 12: 0xFE (254) # Skip 28
# Pos 13: 0x1C (028)
# Pos 14: 0x2D (045) # Draw (45) Twice
# Pos 15: 0x2D (045)
# Pos 16: 0xFE (254) # Skip 255
# Pos 17: 0xFF (255)
# Pos 18: 0xFE (254) # Skip 136
# Pos 19: 0x88 (136)
# Pos 20: 0xE8 (232) # Begin drawing correct image
# ...

# Skip 8 + Draw 1 +
# Skip 29 + Draw 2 +
# Skip 28 + Draw 2 +
# Skip 28 + Draw 2 +
# Skip 255 + Skip 136 = New Total Skip 491
# = Skip 255 (max single skip) + Skip 236

# Desired Bytes
# [0] 4 (Reserved)
# [1..2] 254 255 (Skip 255)
# [3..4] 254 236 (Skip 236)
# [5...] Original [20...] (Move bytes 20 back 15 spots)
# [...last 15] 255 (Fill extra 15 trailing bytes with END code)

# [0] and [1] are correct...
$segment[2] = 255
$segment[3] = 254
$segment[4] = 236
# Move position 20 back 15
for ($i = 20; $i -lt $segment.Length; ++$i) { $segment[$i - 15] = $segment[$i] }
# Fill the last 15 with FF
for ($i = $segment.Length - 15; $i -lt $segment.Length; ++$i) { $segment[$i] = 255 }
# Copy the modified segment back into the original sequence
for ($i = 0; $i -lt $segment.Length; ++$i) { $bytes[17560 + $i] = $segment[$i] }
# Write the fixed file
[System.IO.File]::WriteAllBytes("c:\git\jacobb\XComGenerations\XCom\Content\Units\ImageGroups\Snakeman.bin", $bytes)
