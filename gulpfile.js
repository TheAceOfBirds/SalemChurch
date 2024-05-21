/// <binding BeforeBuild='build' />
const gulp = require('gulp');
const sass = require("gulp-sass")(require("sass"));
const clean = require('gulp-clean');
const concat = require('gulp-concat');

const paths = {
    scripts: {
        src: [
            'assets/js/scripts.js'
        ],
        dest: 'wwwroot/js/'
    },
    styles: {
        src: [
            'assets/scss/**/*.scss'
        ],
        dest: 'wwwroot/css/'
    }
};

function cleanDist() {
    return gulp.src('wwwroot/*', { read: false, allowEmpty: true })
        .pipe(clean());
}

function scripts() {
    return gulp.src(paths.scripts.src)
        .pipe(concat('scripts.js')) // Concatenate files without uglifying
        .pipe(gulp.dest(paths.scripts.dest));
}

function styles() {
    return gulp.src(paths.styles.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css')) // Concatenate files without minifying
        .pipe(gulp.dest(paths.styles.dest));
}

const build = gulp.series(cleanDist, gulp.parallel(scripts, styles));

exports.clean = cleanDist;
exports.scripts = scripts;
exports.styles = styles;
exports.build = build;
exports.default = build;