// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(() => {
	const storageKey = "theme";
	const root = document.documentElement;
	const toggle = document.querySelector(".app-dark-toggle");

	const getPreferredTheme = () => {
		const saved = localStorage.getItem(storageKey);
		if (saved === "dark" || saved === "light") {
			return saved;
		}
		return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
	};

	const applyTheme = (theme) => {
		root.setAttribute("data-theme", theme);
		if (toggle) {
			toggle.setAttribute("aria-pressed", theme === "dark" ? "true" : "false");
		}
	};

	const setTheme = (theme) => {
		localStorage.setItem(storageKey, theme);
		applyTheme(theme);
	};

	applyTheme(getPreferredTheme());

	if (toggle) {
		toggle.addEventListener("click", () => {
			const current = root.getAttribute("data-theme") === "dark" ? "dark" : "light";
			setTheme(current === "dark" ? "light" : "dark");
		});
	}
})();
