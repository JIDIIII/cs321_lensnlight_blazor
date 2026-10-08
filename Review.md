# Review for John David Velos

**Link:** [https://github.com/JIDIIII/cs321_lensnlight_blazor](https://github.com/JIDIIII/cs321_lensnlight_blazor)

---

## Project Structure Rating

### File and folder structure — 4/5
It has a good project structure that features some aspects of vertical slicing which can be seen in the `Features` folder. However, I do need to point out that inside the `Features` subfolders, there exist `Component` folders which also exist in the root directory. This might be intentional but it can lead to confusions later down the road.

### Naming of files/folders — 4/5
Overall the naming of the folders are understandable. This applies to file names as well. However, as pointed above, there are `Components` in the individual and also in the root directory which is a little bit confusing.

### Code organization — 3/5
The problems stems from the fact that the Razor files do not use tailwind as a framework and simply uses vanilla CSS. If ever I'm wrong and tailwind was indeed used, then it was not used for all of the files. If that is the case I do think it is standard to use tailwind for all HTML related files and not rely on vanilla CSS.

### Commit names/messages — 5/5
The commit messages are good and the intent behind the messages are easily understood. The only problem I have is that the commits start at a capital case rather than the standard lower case. However, this is a minor problem that comes down to preference.

### Overall repository organization and cleanliness — 4/5
Overall the repository organization is solid, minus the confusion around the `Components` folder. Another problem is there are three different CSS files. If tailwind was used, normally only one CSS file would be generated. However if the project chooses not to use tailwind then I believe separating the CSS files into three different folders, or even one folder per razor, is standard.

---

## Front-End Rating

### Layout and visual presentation — 5/5
The layout, where the navigation buttons are pressed, and the visuals are simply perfect. There's nothing left to comment. Personally I don't even know how this is possible with such a short amount of development time.

### Usability and navigation — 5/5
Very sleek navigation. It is also very usable, it can simulate booking a camera already. The transition to different pages is also nice.

### Consistency — 5/5
In terms of the actual website, it is very consistent. The theme that was used for one is the same theme used for all. Personally though, I would make the prices use two decimal places, but the site is very consistent with using pure integers as prices.

### Readability — 5/5
Very readable. It uses yellow and white fonts and colors that directly contrast the black background. It also bolds or enlarge key points to make it easier to scan. Like earlier the only problem I have is not using two decimal places for prices, but that doesn't make it unreadable.

### Responsiveness, if applicable — not applicable

### Overall completeness and functionality — 5/5
Very good, everything that it needs (aside from the backend) is there. Very readable and modern design as well. The only problem maybe is not using HD pictures because they came out pixelated but since this is probably just a placeholder so not that much of a problem.
