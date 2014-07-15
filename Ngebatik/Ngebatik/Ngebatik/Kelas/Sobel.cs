using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Ngebatik.Kelas
{
    class Sobel
    {
        private const float PreMultiplyFactor = 1 / 255f;

        WriteableBitmap wbEdited = new WriteableBitmap(400, 280);

        int[,] GX = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        int[,] GY = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

        public WriteableBitmap CitraSobel(WriteableBitmap citraPemilihanWarna)
        {
            #region inisialisasi
            WriteableBitmap b = new WriteableBitmap(citraPemilihanWarna);
            WriteableBitmap bb = new WriteableBitmap(400, 280);
            int width = 400;
            int height = 280;

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;

            int limit = 128 * 128;
            #endregion

            #region body

            int[] rgb = b.Pixels;
            int alpha = 0, red, green, blue;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    alpha = rgb[(j * width) + i] >> 24;
                    red = (rgb[(j * width) + i] & 0x00ff0000) >> 16;
                    green = (rgb[(j * width) + i] & 0x0000ff00) >> 8;
                    blue = (rgb[(j * width) + i] & 0x000000ff);

                    allPixR[i, j] = red;
                    allPixG[i, j] = green;
                    allPixB[i, j] = blue;
                }
            }

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            new_rx += GX[wi + 1, hw + 1] * rc;
                            new_ry += GY[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j + wi];
                            new_gx += GX[wi + 1, hw + 1] * gc;
                            new_gy += GY[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j + wi];
                            new_bx += GX[wi + 1, hw + 1] * bc;
                            new_by += GY[wi + 1, hw + 1] * bc;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                        SetPikselCitra(i, j, (byte)alpha, 0, 0, 0);
                    else
                    {
                        SetPikselCitra(i, j, (byte)alpha, 255, 255, 255);
                    }
                }
            }
            #endregion

            bb = wbEdited;

            return bb;
        }

        public void SetPikselCitra(int x, int y, byte alpha, int r, int g, int b)
        {
            float ai = alpha * PreMultiplyFactor;
            wbEdited.Pixels[(y * 400) + x] = (alpha << 24) | ((byte)(r * ai) << 16) |
                ((byte)(g * ai) << 8) | (byte)(b * ai);

        }
    }
}
