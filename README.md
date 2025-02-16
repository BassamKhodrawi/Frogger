# GDI+
Unsere Sammlung von Tipps und Tricks zum Thema Grafikprogrammierung mit GDI+.

![image alt](https://github.com/GSO-SW/frogger-swe_frogger_k-z/blob/d1bfa1abba48c67e9d6ea30b8a3882044c904fae/Github%20Kater.jpg)

## Basics
### Einstellungen
- `ResizeRedraw = true;` ruft das Paint-Event bei jeder Größenänderung der Form auf.
- `DoubleBuffered = true;` verhindert Flackern bei Animationen.

### Pain-Event überschreiben
Statt ein Paint-Event über die Eigenschaften einer Form hinzuzufügen, kann man auch das vorhandene Paint-Event überschreiben. Diese Technik funktioniert, weil unsere Form von Windows-Forms erbt.
```cs
protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            // ...
        }
```

## Klassen / Ereignisse
### Timer
Ein Timer führt in regelmäßigen Abständen ein `Tick`-Event aus. Nachdem ein Timer deklariert wurde, z.B. mit `private Timer tmrMeinTimer;` muss er noch initialisiert werden `tmrMeinTimer = new Timer();`. Anschließend kann man:
- die Zeit zwischen jedem `Tick`-Event einstellen (`+ Interval { get; set; }: int`) und
- den Timer starten (`+ Start():void`) oder
- stoppen (`+ Stop():void`) oder
- den Zustand abfragen. (`+ Enabled{ get; set; }: bool`) (Standard ist ausgeschaltet: `enabled = false`)
- das Tick-Ereignis zuweisen (`timer.Tick += Timer_Tick`)

Das Tick-Event kann man so erstellen: 
```cs
private void Timer_Tick(object sender, EventArgs e)
    {
        //...
    }
```


## Tipps und Tricks
Ergänzen Sie hier die notwendigen Code-Ausschnitte, um zu zeigen, wie man es macht. 
- Sie können [CodeBlöcke mit Syntax-Highlighting](https://docs.github.com/en/get-started/writing-on-github/working-with-advanced-formatting/creating-and-highlighting-code-blocks#syntax-highlighting) einsetzen
- Wird es zu unübersichtlich? Sie können auch Unterordner mit Beispiel-Code anlegen und auf die entsprechenden Dateien verlinken. [Inspiration](https://github.com/gsoTH/flaskShowcase/tree/master/datenbanken).
- Die folgende Liste kann gerne ergänzt werden :)

### Bewegung animieren

### Objekte mit Tasten steuern

### Verhindern, dass ein Spieler aus dem Bild läuft

### Spiel pausieren

### Ihr schönstes Ergebnis





