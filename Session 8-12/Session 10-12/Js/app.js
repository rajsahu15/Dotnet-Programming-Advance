document.addEventListener("DOMContentLoaded", function () {

    const canvas = document.getElementById("myCanvas");
    const ctx = canvas.getContext("2d");

    let angle = 0;

    // Player square
    let player = {
        x: 100,
        y: 150,
        size: 50,
        speed: 2
    };

    // Enemy circle
    let enemy = {
        x: 500,
        y: 150,
        radius: 30,
        speed: 2
    };

    // Particles array
    let particles = [];

    class Particle {
        constructor(x, y) {
            this.x = x;
            this.y = y;
            this.size = Math.random() * 5 + 2;
            this.speedX = (Math.random() - 0.5) * 4;
            this.speedY = (Math.random() - 0.5) * 4;
            this.life = 100;
        }

        update() {
            this.x += this.speedX;
            this.y += this.speedY;
            this.life--;
        }

        draw() {
            ctx.fillStyle = "#ff1a3c";
            ctx.beginPath();
            ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
            ctx.fill();
        }
    }

    function createExplosion(x, y) {
        for (let i = 0; i < 30; i++) {
            particles.push(new Particle(x, y));
        }
    }

    function collision() {
        let dx = player.x - enemy.x;
        let dy = player.y - enemy.y;
        let distance = Math.sqrt(dx * dx + dy * dy);
        return distance < player.size/2 + enemy.radius;
    }

    function update() {

        angle += 0.02;

        // Move enemy toward player
        if (enemy.x > player.x) enemy.x -= enemy.speed;
        else enemy.x += enemy.speed;

        if (collision()) {
            createExplosion(player.x, player.y);
            enemy.x = 500; // reset enemy
        }

        particles.forEach((p, index) => {
            p.update();
            if (p.life <= 0) particles.splice(index, 1);
        });
    }

    function render() {

        // Gradient background
        let bg = ctx.createLinearGradient(0, 0, canvas.width, canvas.height);
        bg.addColorStop(0, "#0f0f0f");
        bg.addColorStop(1, "#1c1c1c");

        ctx.fillStyle = bg;
        ctx.fillRect(0, 0, canvas.width, canvas.height);

        // Draw rotating player square
        ctx.save();
        ctx.translate(player.x, player.y);
        ctx.rotate(angle);
        ctx.fillStyle = "#b11226";
        ctx.fillRect(-player.size/2, -player.size/2, player.size, player.size);
        ctx.restore();

        // Draw enemy circle
        ctx.fillStyle = "#ff1a3c";
        ctx.beginPath();
        ctx.arc(enemy.x, enemy.y, enemy.radius, 0, Math.PI * 2);
        ctx.fill();

        // Draw particles
        particles.forEach(p => p.draw());
    }

    function gameLoop() {
        update();
        render();
        requestAnimationFrame(gameLoop);
    }

    gameLoop();

});